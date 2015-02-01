using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using webapilab.Models;
using webapilab.Services;
using webapilab;
using System.Web.Http.Cors;

namespace webapilab.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]    
    public class MembersController : ApiController
    {
        private IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            Mapper.CreateMap<Member, MemberViewModel>();
            Mapper.CreateMap<MemberBaseViewModel, Member>();
            Mapper.CreateMap<MemberViewModel, Member>();

            _membersService = membersService;
        }

        // GET api/members
        /// <summary>
        /// Get all team members
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MemberViewModel> Get()
        {
            var members = _membersService.GetAll();            
            return Mapper.Map<IEnumerable<Member>, IEnumerable<MemberViewModel>>(members);
        }

        // GET api/members/5
        public IHttpActionResult Get(int id)
        {
            var member = _membersService.Get(id);
            if (member == null)
            {
                return NotFound();
            }
            var memberViewModel = Mapper.Map<Member, MemberViewModel>(member);
            return Ok(memberViewModel);
        }

        // POST api/members
        public HttpResponseMessage Post(MemberBaseViewModel memberViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var member = Mapper.Map<MemberBaseViewModel, Member>(memberViewModel);
                    _membersService.Add(member);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/members/5
        public HttpResponseMessage Put(MemberViewModel memberViewModel)
        {
            try
            {
                var member = _membersService.Get(memberViewModel.MemberId);
                Mapper.Map(memberViewModel, member);
                _membersService.Update(member);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/members/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _membersService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}