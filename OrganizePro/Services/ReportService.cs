﻿using Microsoft.EntityFrameworkCore;
using OrganizePro.DTOs;
using System.Globalization;

namespace OrganizePro.Services;

public class ReportService
{
    private readonly Context.Context _context;

    public ReportService(Context.Context context)
    {
        _context = context;
    }

    public async Task<List<AppointmentTypeReportDto>> CreateAppointmentTypeReportDto(int year)
    {
        var appointmentData = await _context.Appointments
            .Where(a => a.Start.Year == year)
            .GroupBy(a => a.Start.Month)
            .Select(monthGroup => new
            {
                Month = monthGroup.Key,
                Types = monthGroup
                    .GroupBy(a => a.Type)
                    .Select(typeGroup => new
                    {
                        Type = typeGroup.Key,
                        Count = typeGroup.Count(),
                    })
            })
            .ToListAsync();

        var dto = appointmentData
            .SelectMany(monthGroup => monthGroup.Types
                .Select(typeGroup => new AppointmentTypeReportDto
                {
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthGroup.Month),
                    Type = typeGroup.Type,
                    Count = typeGroup.Count
                }))
            .ToList();

        return dto;
    }


    public async Task<List<UserScheduleReportDto>> CreateUserScheduleReportDto()
    {
        var dto = await _context.Appointments
            .Select(appointment => new UserScheduleReportDto
            {
                Username = appointment.User.Username,
                AppointmentTitle = appointment.Title,
                CustomerName = appointment.Customer.CustomerName,
                AppointmentType = appointment.Type,
                StartTime = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local),
                EndTime = TimeZoneInfo.ConvertTimeToUtc(appointment.End, TimeZoneInfo.Local),
                Location = appointment.Location,
                Contact = appointment.Contact
            })
            .ToListAsync();

        return dto;
    }

    public async Task<List<CustomerSummaryReportDto>> CreateCustomerSummaryReportDto()
    {
        var customerData = await _context.Appointments
            .Join(_context.Customers,
                appointment => appointment.CustomerId,
                customer => customer.Id,
                (appointment, customer) => new { appointment, customer })
            .GroupBy(combined => combined.customer.CustomerName)
            .Select(combined => new
            {
                CustomerName = combined.Key,
                TotalAppointments = combined.Count(),
                MostCommonAppointmentType = combined
                    .GroupBy(c => c.appointment.Type)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .FirstOrDefault()
            }).ToListAsync();

        var dto = customerData.Select(group => new CustomerSummaryReportDto
        {
            CustomerName = group.CustomerName,
            TotalAppointments = group.TotalAppointments,
            MostCommonAppointmentType = group.MostCommonAppointmentType
        }).ToList();

        return dto;
    }
}