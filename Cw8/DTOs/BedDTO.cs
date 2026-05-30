namespace Cw8.DTOs;

public class BedDTO
{
    public int Id { get; set; }

    public virtual BedTypeDTO BedType { get; set; } = null!;

    public virtual RoomDTO Room { get; set; } = null!;
}