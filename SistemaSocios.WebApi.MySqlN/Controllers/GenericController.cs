using Microsoft.AspNetCore.Mvc;
using SistemaSocios.WebApi.MySqlN.model;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;
using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Default")] // Definindo a tag padrão
    public abstract class BaseController<TEntity, TService> : ControllerBase
         where TEntity : DocModel
         where TService : IGenericService<TEntity>
    {
        protected readonly TService _service;
        protected readonly ILogger<TEntity> _loger;
        private IGenericService<UsuarioModel> usuarioService;
        private readonly ITokenService _tokenService;

        public BaseController(TService service, ILogger<TEntity> loger, ITokenService tokenService)
        {
            _service = service;
            ApplySwaggerTags(); // Aplicar as anotações Swagger ao instanciar o controlador
            _loger = loger;
            _tokenService = tokenService;
        }

        protected BaseController(IGenericService<UsuarioModel> usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(new ApiResponse<object>
                {
                    Data = entities,
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.OK,
                });
                //return Ok(entities);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }

        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                {
                    return StatusCode(500, new ApiResponse<object>
                    {
                        Success = false,
                        ErrorMessage = "Recurso não encontrado",
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    });
                    
                }

                return Ok(new ApiResponse<object>
                {
                    Data = entity,
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.OK,
                });
              
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }

        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            try
            {

                if (typeof(TEntity) == typeof(UsuarioModel))
                {
                    var usuario = entity as UsuarioModel;
                    usuario.senha = _tokenService.HashPassword(usuario.senha);
                    await _service.CreateAsync(entity);
                    return Ok(new ApiResponse<object>
                    {
                        Data = entity,
                        Success = true,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        });
                    

                }
                else
                {
                    await _service.CreateAsync(entity);
                    return Ok(new ApiResponse<object>
                    {
                        Data = entity,
                        Success = true,
                        StatusCode = System.Net.HttpStatusCode.OK,
                    });
                   
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }



        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, TEntity entity)
        {
            try
            {
                await _service.UpdateAsync(entity);
                return Ok(new ApiResponse<object>
                {
                    Data = entity,
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                });
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<object> { Success = false, ErrorMessage = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest });
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {

            try
            {
                await _service.DeleteAsync(id);
                return Ok(new ApiResponse<object>
                {
                    Data = id,
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                });

                
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<object> { Success = false, ErrorMessage = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest });
            }
        }

        protected void ApplySwaggerTags()
        {
            var entityType = typeof(TEntity);
            var swaggerTagAttribute = entityType.GetCustomAttribute<SwaggerTagAttribute>();
            if (swaggerTagAttribute != null)
            {
                var controllerType = GetType();
                var controllerSwaggerTagAttribute = controllerType.GetCustomAttribute<SwaggerTagAttribute>();
                if (controllerSwaggerTagAttribute == null)
                {
                    // Define a tag do Swagger para o controlador baseado na classe TEntity
                    var controllerSwaggerTag = new SwaggerTagAttribute(swaggerTagAttribute.Description);
                    controllerType.GetCustomAttributes().ToList().Add(controllerSwaggerTag);
                }

                var methods = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => m.DeclaringType == controllerType && !m.IsSpecialName); // Exclude properties, constructors, etc.

                foreach (var method in methods)
                {
                    var methodSwaggerOperationAttribute = method.GetCustomAttribute<SwaggerOperationAttribute>();
                    if (methodSwaggerOperationAttribute == null)
                    {
                        // Define a descrição da operação do Swagger com base no nome do método
                        var methodSummary = $"{method.Name} {entityType.Name}";
                        var methodSwaggerOperation = new SwaggerOperationAttribute { Summary = methodSummary };
                        method.GetCustomAttributes().ToList().Add(methodSwaggerOperation);
                    }
                }
            }
        }


        // Método auxiliar para obter o ID da entidade
        protected abstract string GetEntityId(TEntity entity);
    }
}
