using System;
using System.ComponentModel.DataAnnotations;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

public class GetAttachmentRequestDto
{
    [Required] 
    public Guid Id { get; set; }
}