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
             Username = appointment.User.Username,
             CustomerName = appointment.Customer.CustomerName,
             Title = appointment.Title,
             Type = appointment.Type,
             Location = appointment.Location,
             Contact = appointment.Contact,
             Description = appointment.Description,
             URL = appointment.Url,
             Start = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local),
             End = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local)
         })
         .ToListAsync()) 
         .AsEnumerable()
         .OrderBy(appointment => appointment.Start)
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
                Username = a.User.Username,
                CustomerName = a.Customer.CustomerName,
                Title = a.Title,
                Type = a.Type,
                Location = a.Location,
                Contact = a.Contact,
                Description = a.Description,
                URL = a.Url,
                Start = TimeZoneInfo.ConvertTimeFromUtc(a.Start, TimeZoneInfo.Local),
                End = TimeZoneInfo.ConvertTimeFromUtc(a.End, TimeZoneInfo.Local)
            }).ToList();

        return dto;
    }
}