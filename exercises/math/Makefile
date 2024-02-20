Out.txt: main.exe
	mono main.exe > Out.txt

main.exe : main.cs sfunc.dll
	mcs main.cs -target:exe -out:main.exe -reference:sfunc.dll

sfunc.dll : sfunc.cs
	mcs -target:library -out:sfunc.dll sfunc.cs

clean:
	rm -f Out.txt main.exe
