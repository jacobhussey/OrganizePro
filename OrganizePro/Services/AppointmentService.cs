using Microsoft.EntityFrameworkCore;
using OrganizePro.DTOs;
using OrganizePro.Models;

namespace OrganizePro.Services;

public class AppointmentService(Context.Context context) : EntityBaseService<Appointment, Context.Context>(context)
{
    public override async Task<Appointment> GetEntityByIdAsync(int id)
    {
        return await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override async Task<List<Appointment>> GetAllAsync()
    {
        return await _context
            .Set<Appointment>()
            .Include(a => a.Customer)
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<List<AppointmentTableDto>> CreateAppointmentTableDto()
    {
        var appointmentData = (await _context.Appointments
         .Select(appointment => new AppointmentTableDto
         {
             Id = appointment.Id,
             Title = appointment.Title,
             CustomerName = appointment.Customer.CustomerName,
             Username = appointment.User.Username,
             Type = appointment.Type,
             Start = appointment.Start,
             End = appointment.End,
             Location = appointment.Location,
             Contact = appointment.Contact
         })
         .ToListAsync()) 
         .AsEnumerable()
         .OrderBy(appointment => TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local)) // Perform local sorting
         .ToList();

        return appointmentData;
    }

    public async Task<List<AppointmentTableDto>> CreateCalendarAppointmentTableDto(DateTime date)
    {
        var appointments = await GetAllAsync();

        var dto = appointments
            .Where(a => a.Start.Date == date.Date)
            .Select(a => new AppointmentTableDto
            {
                Title = a.Title,
                Type = a.Type,
                Username = a.User.Username,
                CustomerName = a.Customer.CustomerName,
                Location = a.Location,
                Contact = a.Contact,
                Start = TimeZoneInfo.ConvertTimeFromUtc(a.Start, TimeZoneInfo.Local),
                End = TimeZoneInfo.ConvertTimeFromUtc(a.End, TimeZoneInfo.Local)
            }).ToList();

        return dto;
    }
}