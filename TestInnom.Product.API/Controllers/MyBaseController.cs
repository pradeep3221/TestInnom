using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using TestInnom.Product.Manager;

namespace TestInnom.Product.Api.Controllers
{
    /// <summary>
    /// Provide automatic support for the most common web api controller action like get, post, put and delete,
    /// we can use TEntity or T
    /// </summary>
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class MyBaseController<TEntity> : Controller where TEntity : class //,  IIdentifier
    {
        private IBaseManager<TEntity> _baseManager;

        /// <summary>
        /// Base Controller Constructor
        /// </summary>
        public MyBaseController(IBaseManager<TEntity> BaseManager)
        {
            _baseManager = BaseManager; // need to implement DI
        }

        [HttpGet]
        [Route("GetByID/{id:int}"), ActionName("GetByID")]
        public IActionResult Get(int id)
        {
            TEntity _TEntity = _baseManager.Get(id);

            if (_TEntity == null)
            {
                return NotFound();
            }

            return Ok(_TEntity);
        }

        [HttpGet]
        [Route("GetAll"), ActionName("GetALL")]
        public IActionResult GetALL()
        {
            ICollection<TEntity> _TEntity = _baseManager.GetAll();

            if (_TEntity == null)
            {
                return NotFound();
            }

            return Ok(_TEntity);
        }

        /// <summary>
        /// Create the Resource
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add"), ActionName("Add")]
        public ActionResult Add(TEntity t)
        {
            if (t == null)
            {
                return BadRequest("Object cant be null");
            }
            return Ok(_baseManager.Add(t));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tList"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddAll")]
        public IActionResult AddALL(IEnumerable<TEntity> tList)
        {
            if (tList == null && tList.Count() > 0)
            {
                return BadRequest("Object cant be null");
            }
            return Ok(_baseManager.AddAll(tList));
        }


        [HttpPut]
        [Route("Update/{key:int}"), ActionName("Update/{key:int}")]
        public IActionResult Update(TEntity updated, int key)
        {
            if (updated == null && key > 0)
            {
                return BadRequest("Object cant be null");
            }
            return Ok(_baseManager.Update(updated, key));
        }

        [HttpDelete]
        [Route("Delete"), ActionName("Delete")]
        public IActionResult Delete(TEntity t)
        {
            _baseManager.Delete(t);
            return Ok();
        }

        [HttpGet]
        [Route("Count"), ActionName("Count")]
        public IActionResult Count()
        {
            return Ok(_baseManager.Count());

        }

    }

}