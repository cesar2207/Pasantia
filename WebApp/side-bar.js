let menu = document.getElementById("menu");
let cerrarMenu = document.getElementById('btn-cerrar');
cerrarMenu.addEventListener('click', function() {
    document.getElementById('side-menu').style.width = '0';
});
menu.addEventListener('click', function() {
    document.getElementById('side-menu').style.width = '300px';
});