#pragma strict

function Start () {

}

function Update () {

}

function testPrint(str,c:int)
{
for(var i=0;i<c;i++)
    print(str+":"+i);
}

function testPrint2( array:Array)
{
for(var i=0;i<array.length;i++){
 print(i+":"+array[i]);
}
}