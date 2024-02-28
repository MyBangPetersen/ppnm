Out.txt: main1.exe main2.exe main3.exe Makefile
	mono main1.exe -numbers:1,2,3,4,5 > $@
	echo 6 7 8 9 10 | mono main2.exe 2>> $@
	mono main3.exe -input:input.txt -output:Out.txt

main1.exe: main1.cs
	mcs -target:exe -out:$@ $<
main2.exe: main2.cs
	mcs -target:exe -out:$@ $<

main3.exe: main3.cs
	mcs -target:exe -out:$@ $<

.PHONEY: clean
clean:
	rm -f main1.exe main2.exe main3.exe Out.txt
