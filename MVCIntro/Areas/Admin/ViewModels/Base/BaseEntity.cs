namespace MVCIntro.Areas.Admin.ViewModels.Base;
public abstract class VMBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }

}
