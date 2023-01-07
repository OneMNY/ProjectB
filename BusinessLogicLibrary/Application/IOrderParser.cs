using BusinessLogicLibrary.Model;

namespace BusinessLogicLibrary.Application
{
    public interface IOrderParser
    {
        OrderModel FromDtoToModel(OrderWrapperXmlDto wrapperDto);
        OrderWrapperXmlDto FromModelToDto(OrderModel orderModel);
        string GetXmlString<T>(T wrapperDto);
    }
}