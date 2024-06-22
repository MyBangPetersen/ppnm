Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs matrix.dll
	mcs main.cs -reference:matrix.dll -target:exe -out:main.exe

eigenup.exe: eigenup.cs matrix.dll
	mcs eigenup.exe -reference:matrix.dll -target:exe -out:eigenup.exe

matrix.dll: vector.cs matrix.cs
	mcs -target:library -out:matrix.dll $^

vals.dll: vals.cs vector.dll matrix.dll
        mcs -target:library -reference:matrix.dll -reference:vector.dll $<

clean:
	rm -f *.dll *.exe [Oo]ut.txt
