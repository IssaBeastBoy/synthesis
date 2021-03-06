﻿module Synthesis

let abelar v = v>12 && v<3097 && v%12=0
(*
    let check n=
        let check2 y=
            match y%12=0 with
            |true -> true
            |false -> false
        match n<3097 with
        |true -> check2 v
        |false-> false
    match v>12 with
    |true-> check v
    | false -> false
    *)

let area b h = match h>=0.0 && b>=0.0 with
    | true ->  0.5*b*h
    | false ->  failwith "base or height negative"
  
    
        

let zollo k = match k<0 with
    | true -> -1*k
    | false -> k*2

let min t z = match t<z with
    |true -> t
    |false -> z

let max t z = match t<z with
    |true -> z
    |false -> t

let ofTime x y z = (x*60*60)+(y*60)+z

let toTime y =match y>0 with
     | true -> 
        let min= (y/60)%60
        let hr =(y/60)/60
        let sec=y%60
        hr,min,sec
     |false -> 0,0,0

let digits l =
    let rec num v s= match l/v=0 with
        | true -> s
        | false -> num (v*10) (s+1)
    num 10 1

let minmax y = 
    let v,f,g,h=y
    min(min v f) (min g h), max (max(min v f) (max v h)) (max f g)


let isLeap y = match y%4=0, y%400=0, y%100=0, y<1582 with
    | _,_,_,true -> failwith "Input less then 1582"
    | true,false,true,_-> false
    | true,true,true,_ |true,_,_,_ -> true
    |_-> false

let month y = match y>0, y<13,y/1 with
    | true,true,1 ->("January", 31)
    | true,true,2->("February", 28)
    | true,true,3->("March", 31)
    | true,true,4->("April", 30)
    | true,true,5->("May", 31)
    | true,true,6-> ("June", 30)
    | true,true,7-> ("July", 31)
    | true,true,8-> ("August", 31)
    | true,true,9-> ("September", 30)
    | true,true,10-> ("October", 31)
    | true,true,11 -> ("November", 30)
    | true,true,12 ->  ("December", 31)
    | _ -> failwith "Not implemented"

let toBinary y =
    let rec convert x d = match x%2=0,x/2=0, x=0,x<0, (x>2 && x<0), (x>1 && x=0),y=0 with
       | true,true,true,false,false,false,false->d
       |_,_,_,_,_,_,true -> "0"
       | _,_,_,true,true,false,false-> "1"
       | true,false,false,false,false,false,false-> convert(x/2) ("0"+d)
       | false, true,false,false,false,false,false-> convert(x/2) ("1"+d)
       | false, false,false,false,false,false,false-> convert(x/2) ("1"+d)
       |_,_,_,true,false,false,false -> failwith " "
    convert y ""

let bizFuzz y = match y>2 with
    | true -> 
        let n3= y/3
        let n5 =y/5
        let n35=(y/5)/3
        n3,n5,n35
    |false -> 0,0,0 

let monthDay y x =
    let months = match  y<=0, y>366, isLeap x with
        | false,false,_-> 
            match y=366 && (isLeap x)=false with 
            |true -> failwith ".. "
            | false->
                let rec mon f r j=
                    let m,p= month f
                    let newp = match (m="February" && isLeap x) with 
                    | true -> p+1
                    | false-> p
                    match r<=newp with
                    | true-> j
                    | false-> mon (f+1) (r-newp) (j+1)
                mon 1 y 1
        | _ ->  failwith ".. "
    let g,o= month months
    g    



let coord input1 = 
    let l,h=input1
    let y= fun (k,j)-> (((l-k)**2.0) + ((h-j)**2.0))**0.5 
    let x = fun (e,q) t w -> (l>=e && l<=(e+t)) && (h<=q && h>=(q-w))
    (y,x)                       

