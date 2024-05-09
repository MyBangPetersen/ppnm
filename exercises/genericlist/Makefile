Out.txt : main.exe
	mono main.exe input:input.txt -output:$@

main.exe : main.cs glist.dll
	mcs main.cs -reference:glist.dll

glist.dll : glist.cs
	mcs -target:library -out:glist.dll glist.cs

clean:
	rm -f [oO]ut.txt main.exe *.dll
