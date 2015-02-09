using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using webapilab.entities;
using webapilab.Infrastructure;
using webapilab.Models;
using webapilab.services;

namespace webapilab.Controllers
{
    public class MembersController : ApiController
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            Mapper.CreateMap<Member, MemberViewModel>();
            Mapper.CreateMap<MemberBaseViewModel, Member>();
            Mapper.CreateMap<MemberViewModel, Member>();

            _membersService = membersService;
        }

        public async Task<IEnumerable<MemberViewModel>> Get()
        {
            var members = await _membersService.GetAll();
            return Mapper.Map<IEnumerable<Member>, IEnumerable<MemberViewModel>>(members);
        }

        // GET api/members/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var member = await _membersService.Get(id);
            if (member == null)
            {
                return NotFound();
            }
            var memberViewModel = Mapper.Map<Member, MemberViewModel>(member);
            return Ok(memberViewModel);
        }

        // POST api/members
        public async Task<HttpResponseMessage> Post(MemberBaseViewModel memberViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var member = Mapper.Map<MemberBaseViewModel, Member>(memberViewModel);
                    await _membersService.Add(member);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/members/5
        public async Task<HttpResponseMessage> Put(MemberViewModel memberViewModel)
        {
            try
            {
                var member = await _membersService.Get(memberViewModel.MemberId);
                Mapper.Map(memberViewModel, member);
                await _membersService.Update(member);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/members/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _membersService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}