let highscore = 0;
let numeroIngresado = '';
let score = 20;
let numero = '';

function iniciar() {
    numero = Math.round(Math.random()*19) + 1
    score = 20;
    render("Iniciar Juego");
    txtNro.innerHTML = "Nro: ?"
}

function probar(){
    let mensaje;
    if (numeroIngresado == numero) {
        acertaste()
        return;
    }
    score--;
    if (score === 0) {
        mensaje = "Perdiste!.. Reinicia el juego!";
        return;
    }
    if (numeroIngresado - numero >= 10) {
        mensaje = "Numero muy alto, intenta nuevamente!";
    }
    else if (numeroIngresado - numero <= -10) {
        mensaje = "Numero muy bajo, intenta nuevamente!";
    } else {
        mensaje = "Numero incorrecto, intenta nuevamente!";
    }
    render(mensaje);
}

function acertaste(){
    render("Acertaste!, Tu puntuación fue de " + score)
    txtNro.innerHTML = "Nro: " + numero
    if (score > highscore){
        highscore = score;
    }
    score = 0;
}

function validar() {
    if (score === 0){
        alert("Para continuar jugando, debe reiniciar el juego");
        return false;
    }
    numeroIngresado = document.getElementById('numeroIngresado').value
    if (numeroIngresado === '') {
        alert("Debe ingresar un numero")
        return false;
    }
    if (numeroIngresado >20 || numeroIngresado<1){
        alert("Debe elegir un numero entre 1 y 20")
        return false;
    }
    return true;
}

function load() {
    const btnProbar = document.getElementById("btnProbar");
    btnProbar.addEventListener("click", function () {
        if (validar()){
            probar()
        }
        document.getElementById('numeroIngresado').value = '';
    })

    const btnReiniciar = document.getElementById("btnReiniciar");
    btnReiniciar.addEventListener("click", function () {
        alert("El juego se reinicio!")
        iniciar()
    })

    };

function render(mensaje){
    txtResultado.innerHTML = mensaje
    txtScore.innerHTML = "Score: " + score
    txtHighscore.innerHTML = "Highscore: " + highscore
}

window.onload = function (){
    const txtResultado = document.getElementById("txtResultado");
    const txtScore = document.getElementById("txtScore");
    const txtHighscore = document.getElementById("txtHighscore");   
    const txtNro = document.getElementById("txtNro"); 
    iniciar();
    load();
}; 

