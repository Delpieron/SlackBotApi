using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualDesk.Contracts;
using VirtualDesk.Services;
using VirtualDesk.Contracts.Requests;
using VirtualDesk.Models;
using VirtualDesk.Contracts.Responses;
using VirtualDesk.Contracts.Requests.Slack;
using System.IO;

namespace VirtualDesk.Controllers
{
    [ApiController]
    public class SlackBotController : ControllerBase
    {
        private readonly ISlackBotService slackBotService;
        public SlackBotController(ISlackBotService slackBotService)
        {
            this.slackBotService = slackBotService;
        }
        /// <summary>
        /// Wyślij wiadomość
        /// </summary>
        /// <param name="msgRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.SlackBot.SlackBotMsg)]
        public async Task<IActionResult> SendAsync([FromForm]SlackMsgRequest msgRequest)
        {
            await slackBotService.SendAsync(msgRequest);
            var response = new SlackBotResponses { text = msgRequest.text, channel = msgRequest.channel };
            return Ok(response);
        }
        /// <summary>
        /// Wyślij załącznik
        /// </summary>
        /// <param name="attRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.SlackBot.SlackBotFile)]
        public async Task<IActionResult> UploadFileAsync([FromForm]SlackAttachmentRequest attRequest)
        {
            if (attRequest.File.Length > 0)
            {
                await slackBotService.UploadFileAsync("userToken", attRequest.File.OpenReadStream(), attRequest.File.FileName, attRequest.channel);
            }
            return Ok();
        }

        /// <summary>
        /// Odczytaj wiadomości z danego kanału
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.SlackBot.SlackBotMessages)]
        public async Task<IActionResult> GetMessageAsync([FromRoute]string channel)
        {
            var response = await slackBotService.GetMessageAsync(channel);

            return Ok(response);
        }
        /// <summary>
        /// Pobierz wszystkie dostępne kanały
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.SlackBot.SlackBot_)]
        public async Task<IActionResult> GetChannels()
        {
            var response = await slackBotService.GetChannelsListAsync();
            return Ok(response);
        }
    }
}