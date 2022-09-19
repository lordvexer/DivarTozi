using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Iptb.DivarTozi.Controllers;

public class FileController : DivarToziController
{
    private readonly IAgahiAttachmentAppService _service;

    public FileController(IAgahiAttachmentAppService service)
    {
        _service = service;
    }
    [HttpGet]
    [Route("agahi/photos/{id}")]
    public async Task<IActionResult> DownloadBookOfAccountFactorAttachmentAsync(Guid id)
    {
        var fileDto = await _service.GetBlobAsync(new GetAttachmentRequestDto { Id = id});

        System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
        {
            FileName = fileDto.Name,
            Inline = true
        };
        Response.Headers.Add("Pragma", "public");
        Response.Headers.Add("Expires", "0");
        Response.Headers.Add("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
        Response.Headers.Add("Content-Transfer-Encoding", "binary");
        Response.Headers.Add("Content-Length", fileDto.Content.Length.ToString());
        //Response.Headers.Add("Content-Disposition", cd.ToString());
        Response.Headers.Add("X-Content-Type-Options", "nosniff");

        var contentType = "application/octet-stream";
        switch (fileDto.Extension)
        {
            case ".jpeg":
            case ".jpg":
                contentType = "image/jpeg";
                break;
            case ".mp3":
                contentType = "audio/mpeg";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".pdf":
                contentType = "application/pdf";
                break;
            default:
                break;
        }
        Response.ContentType = contentType;
        return File(fileDto.Content, contentType, fileDto.Name);
    }

}