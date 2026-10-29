namespace FitnessClub.Application.Exceptions;

/// <summary>
/// Операция противоречит текущему состоянию данных
/// </summary>
public class ConflictException(string message) : Exception(message);