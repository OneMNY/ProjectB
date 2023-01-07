using AutoMapper;
using BusinessLogicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusinessLogicLibrary.Application
{
    public class OrderParser : IOrderParser
    {
        private readonly IMapper _mapper;

        public OrderParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderModel FromDtoToModel(OrderWrapperXmlDto wrapperDto)
        {
            var model = new OrderModel
            {
                Header = _mapper.Map<OrderHeaderModel>(wrapperDto.Order.Header),
                Details = _mapper.Map<List<OrderDetailModel>>(wrapperDto.Order.Details)
            };
            return model;
        }

        public OrderWrapperXmlDto FromModelToDto(OrderModel orderModel)
        {
            var wrapper = new OrderWrapperXmlDto
            {
                Order = new OrderDto
                {
                    Header = _mapper.Map<OrderHeaderDto>(orderModel.Header),
                    Details = _mapper.Map<List<OrderDetailDto>>(orderModel.Details)
                }
            };
            return wrapper;
        }

        string IOrderParser.GetXmlString<T>(T wrapperDto)
        {
            // remove namespace
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            // Pass the XmlAttributeOverrides object to the XmlSerializer constructor
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Serialize the DTO to an XML object
            using (var writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                serializer.Serialize(writer, wrapperDto, ns);
                return writer.ToString();
            }
        }
    }
}
