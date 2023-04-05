namespace danj_backend.Data;

public interface ISystemGen
{
    int genCodeId { get; set; }
    int product_id { get; set; }
    Guid systemCode { get; set; }
    char status { get; set; }
    DateTime createdAt { get; set; }
    DateTime updatedAt { get; set; }
}