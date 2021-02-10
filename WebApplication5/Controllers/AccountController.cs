using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication5.Dtos;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly dbContext _context;

        public AccountController(dbContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCustomer loginCustomer)
        {
            RestaurantOwner restaurantOwner = await LoginUser(loginCustomer);
            if ( restaurantOwner != null)
            {
                // MyapiCustomer customer = _context.MyapiCustomers.FirstOrDefault(c => c.Email == loginCustomer.Username);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, restaurantOwner.Restaurant.Name),
                    new Claim(ClaimTypes.NameIdentifier,restaurantOwner.Restaurant.Id.ToString()),
                    new Claim("FullName", restaurantOwner.email)

                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Orders");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        private async Task<RestaurantOwner> LoginUser(LoginCustomer loginCustomer)
        {
            RestaurantOwner restaurantOwner =  _context.RestaurantOwners.Include(r => r.Restaurant).FirstOrDefault(r => r.email == loginCustomer.Username);
            if(restaurantOwner.password == loginCustomer.Password)
            {
                return restaurantOwner;
            }
            return null;
         //   var client = _httpClientFactory.CreateClient();
         //   client.BaseAddress = new Uri("http://127.0.0.1:8000");
         //   client.DefaultRequestHeaders.Accept.Clear();
         //   client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         //   var formContent = new FormUrlEncodedContent(new[]
         //{

         //    new KeyValuePair<string, string>("email", loginCustomer.Username),
         //    new KeyValuePair<string, string>("password", loginCustomer.Password),
         //});

         //   using var httpResponse =
         //       await client.PostAsync("/rest-auth/login/", formContent);

         //   if (httpResponse.IsSuccessStatusCode)
         //   {
               
         //       return true;
         //   }
         //   else
         //   {
         //       return false;
         //   }

        }
    }
}

