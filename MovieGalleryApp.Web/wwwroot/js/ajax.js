const Init = function () {
    let button = document.getElementById("moviesLoadButton");
    let div = document.getElementById("moviesUSContainer");
    
    button.onclick = function (e) {
        e.preventDefault();
        fetch("/Home/GetData")
            .then(response => response.json())
            .then(data => {
                console.log(data);
                for (let i = 0; i < data.length; i++) {
                    div.appendChild(CreateDiv(data[i]));
                }
            });
        button.style.display = "none";
    }
};

const CreateDiv = function (data) {
    let div = document.createElement("div");
    div.classList.add("movie-list-item");

    let img = document.createElement("img");
    img.classList.add("movie-list-item-img")
    img.src = data.imgUrl

    let span = document.createElement("span");
    span.classList.add("movie-list-item-title")
    span.textContent = data.title

    let p = document.createElement("p");
    p.classList.add("movie-list-item-desc");
    p.textContent = data.description;

    let a = document.createElement("a");
    a.classList.add("movie-list-item-button");
    a.href = `/Movie/Details/${data.id}`
    a.textContent = "Details";

    div.appendChild(img);
    div.appendChild(span);
    div.appendChild(p);
    div.appendChild(a);

    return div;
}

window.onload = Init();

//<div class="movie-list-item">
//    <img class="movie-list-item-img" src="~/img/17.jpg" alt="">
//        <span class="movie-list-item-title">Her</span>
//        <p class="movie-list-item-desc">
//            Lorem ipsum dolor sit amet consectetur adipisicing elit. At
//            hic fugit similique accusantium.
//        </p>
//        <button class="movie-list-item-button">Watch</button>
//                </div>