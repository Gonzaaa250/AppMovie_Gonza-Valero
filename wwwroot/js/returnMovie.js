function CargarPaginasDevolucion() {
    SearchReturnTmp();
}

function Agregarpeliculasdevolucion() {
    // console.log("Funcion de agregar pelicula temporal activada")
    var movieID = $("#MovieID").val();
    $.ajax({
        type: "POST",
        url: "../../Return/AgregarPeliculas",
        data: { MovieID: movieID },
        success: function (resultado) {
            if (resultado == true) {
                $("#staticBackdrop").modal("hide");
                SearchReturnTmp();
                location.href = "../../Return/Create";
            } 
        },
        error: function(_result) {
            console.log("Error debido a: " + _result)
        },
    });
}

function CancelReturn() {
    $.ajax({
        type: "POST",
        url: "../../Return/CancelarDevolucion",
        data: {},
        success: function(resultado){
            if(resultado = true)
            {           
                    location.href = "../../Return/Index";
            }
        },
        error(result){

        }
    })
}

function SearchReturnTmp() {
    $.ajax({
        type: "GET",
        url: "../../Return/SearchMovieTmp",
        data: {},
        success: function(ListadoMovieTmp){
            // console.log(ListadoMovieTmp)
            $.each(ListadoMovieTmp, function(index, item){
                $("#tbody-Devolucion").append(
                    `<tr>
                        <th>${item.movieName}</th>
                        <th>
                            <button class="btn botonEliminar" onclick="QuitarMovieReturn(${item.movieID});">Quitar Peliculas</button>
                        </th>
                    </tr>`
                );
            });
        },
        error(result){

        }
    })
}

function QuitarMovieReturn(id){   
                $.ajax({
                    type: "POST",
                    url: "../../Return/QuitarMovie",
                    data: {MovieID: id},
                    success: function(resultado){
                        if(resultado == true){
                            location.href = "../../Return/Create";
                        }
                    }
                });
            }
 function SearchMovieReturn(ReturnID) {
    $('#tbody-peliculasReturn').empty();
    $.ajax({
        type: "POST",
        url: "../../Return/SearchMovie",
        data: {ReturnID: ReturnID},
        success: function(ListadoMovie){
            // console.log(ListadoMovie)
            $.each(ListadoMovie, function(index, item){
                $("#tbody-peliculasReturn").append(
                    `<tr>
                        <th>${item.movieName}</th>
                    </tr>`
                );
            });
        },
        error(result){

        }
    })
}