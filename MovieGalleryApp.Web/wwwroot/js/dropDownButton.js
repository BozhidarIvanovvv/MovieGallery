let click = document.querySelector('.button-click');

let list = document.querySelector('.button-list');

click.addEventListener("click", () => {

    list.classList.toggle('newlist');

});