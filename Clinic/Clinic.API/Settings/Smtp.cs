namespace Clinic.API.Settings;

public record Smtp(
    string Host,
    int Port,
    string Username, 
    string Password,
    string FromEmail,
    string FromName
);
