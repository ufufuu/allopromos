// Decompiled with JetBrains decompiler
// Type: allopromo.Api.Commands.Model.AddProductPictureCommand
// Assembly: allopromo.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9E70BF9-6813-49CA-B8B2-EE280C9B986F
// Assembly location: C:\Users\MonPC\Downloads\allopromo.Api.dll

using allopromo.Api.DTOs;
using MediatR;

#nullable disable
namespace allopromo.Api.Commands.Model
{
    public class AddProductPictureCommand : IRequest<bool>, IBaseRequest
    {
        public ProductDto Product { get; set; }
    }
}
