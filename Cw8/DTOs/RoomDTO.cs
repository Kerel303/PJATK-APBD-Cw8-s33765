namespace Cw8.DTOs;

public class RoomDTO
{
    public string Id { get; set; } = null!;

    public bool HasTv { get; set; }

    public virtual WardDTO Ward { get; set; } = null!;
}