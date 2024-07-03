namespace Clinic.API.Models.Appointment;

public class AppointmentResponse
{
    public Guid Id { get; set; }
    public DateTime ScheduledTime { get; set; }
    public bool IsApproved { get; set; }
    public decimal Price { get; set; }
    public Doctor.DoctorResponse Doctor { get; set; }
    public Patient.PatientResponse Patient { get; set; }

    public AppointmentResponse(Domain.Entities.Appointment appointment)
    {
        Id = appointment.Id;
        ScheduledTime = appointment.ScheduledTime;
        IsApproved = appointment.IsApproved;
        Price = appointment.Price;
        Patient = new (appointment.Patient);
        Doctor = new(appointment.Doctor);
    }
}
