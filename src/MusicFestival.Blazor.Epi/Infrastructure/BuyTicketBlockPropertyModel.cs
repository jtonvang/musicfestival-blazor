﻿using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.SpecializedProperties;
using MusicFestival.Blazor.Epi.Models.Blocks;

namespace MusicFestival.Blazor.Epi.Infrastructure
{
    /// <summary>
    /// This class is used by the <see cref="MusicFestival.Template.Models.ExtendedContentModelMapper"/>
    /// in order to get the actual value from the property model.
    /// </summary>
    public class BuyTicketBlockPropertyModel : PropertyModel<object, PropertyBlock>
    {
        public BuyTicketBlockPropertyModel(PropertyBlock value)
            : base(value)
        {
            Value = new
            {
                ((BuyTicketBlock)value.Value).Heading,
                ((BuyTicketBlock)value.Value).Message
            };
        }
    }
}