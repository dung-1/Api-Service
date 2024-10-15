namespace Api_Service.Model
{
    public abstract class BaseModel
    {
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedTime { get; set; } = DateTime.UtcNow;
    }

}
