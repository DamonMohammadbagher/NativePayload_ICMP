# NativePayload_ICMP 

NativePayload_ICMP  v2.0 C# Code Released for Ebook.

1. NativePayload_ICMP.exe syntax :

NativePayload_ICMP.exe  help  

2. NativePayload_ICMP.sh  "test version"  syntax:

NativePayload_ICMP.sh  "w.x.y.z" 

"w.x.y.z" is TargetIPv4 to Listening , it means your system will send Ping request to This IPv4 to Listening TTL values from Ping Respnse.  you can use this Script with "Script.sh" file and this file should Created by NativePayload_ICMP.exe command via this syntax :

Syntax : NativePayload_ICMP.exe  shtext  "your text or string"

after this step you will have Script.sh file then you can use that from "Client side" after this step then you can use (NativePayload_ICMP.sh  "w.x.y.z" ) from "Server side"  to send Ping Request to "Client Side":

step 0 (windows side) : NativePayload_ICMP.exe shtext "your test text or String"

Note: with "step0" you will have new Script File with name "Script.sh" .

step 1 (client side) with IPv4 (192.168.10.10) : ./script.sh

step 2 (server side) : ./NativePayload_ICMP.sh  "192.168.10.10" 

Note: "Step 2" should run after "Step 1" immediately after "2 or 3" seconds 
