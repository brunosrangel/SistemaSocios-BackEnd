using Microsoft.AspNetCore.Mvc;
using SistemaSocios.Core.Model.Usuario;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsuarios()
    {
        var usuarios = await _usuarioService.GetAllUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioById(string id)
    {
        var usuario = await _usuarioService.GetUsuarioById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> AddUsuario(UsuarioModel usuario)
    {
        await _usuarioService.AddUsuario(usuario);
        return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.idUsuario }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(string id, UsuarioModel usuario)
    {
        var updated = await _usuarioService.UpdateUsuario(id, usuario);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(string id)
    {
        var deleted = await _usuarioService.DeleteUsuario(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
