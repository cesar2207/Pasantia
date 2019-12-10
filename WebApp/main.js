let modal = document.getElementById('iniciar-Sesion');
let flex = document.getElementById('flex');
let iniciar = document.getElementById('iniciar_s');
let cerrar = document.getElementById('cerrar');

iniciar.addEventListener('click', function() {
    modal.style.display = 'block';
});

cerrar.addEventListener('click', function() {
    modal.style.display = 'none';
});

window.addEventListener('click', function(e) {
    console.log(e.target);
    if (e.target == flex) {
        modal.style.display = 'none';
    }
});