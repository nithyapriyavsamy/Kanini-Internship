function check(){
    var OriWord = document.getElementById("ow").value;
    var GuessWord = document.getElementById("gw").value;
    var cow=0;
    var bull=0;
        for(var i=0;i<OriWord.length;i++){
            for(var j=0;j<GuessWord.length;j++){
                if(OriWord.charAt(i)==GuessWord.charAt(j)){
                    if(i==j)
                        cow+=1;
                    else
                        bull+=1;
                }
            }
        }  
    console.log("cow = "+ cow+"  "+"bull = "+bull);
    document.getElementById("gw").value="";
    document.getElementById("div2").innerHTML="COW = "+cow+"<br>"+"BULL = "+bull+"<br>";
    if(cow==OriWord.length){
        console.log("you win!!!");
        var node=document.createElement("e");
        var txtNode=document.createTextNode("You Win!!!");
        node.appendChild(txtNode);
        document.getElementById("div2").appendChild(node);
       }
}     