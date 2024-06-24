var movies = [];
var movie={
    name: "",
    duration :0,
    rating:0

}
function assignMovieData(){
    movie = new Object();
    
    movie.name=document.getElementById("mname").value;
    movie.duration=document.getElementById("mdn").value *1;
    movie.rating=document.getElementById("mrate").value*1;
    console.log(movie);
    movies.push(movie);
    document.getElementById("mname").value="";
    document.getElementById("mdn").value=0;
    document.getElementById("mrate").value=0;
}
function showMovieData(){
    var myDiv=document.getElementById("msgDiv");
    var html="<table border>";
    html+="<tr>";
    html+="<td colspan=3>"+"Registrations"+"</td>";
    for(var i=0;i<movies.length;i++){
        html+="<tr>";
        html+="<td>"+movies[i].name+"</td>";
        html+="<td>"+movies[i].duration+"</td>";
        html+="<td>"+movies[i].rating+"</td>";
        html+="</tr>";
    }
    html+="</table>";
    myDiv.innerHTML=html;
}