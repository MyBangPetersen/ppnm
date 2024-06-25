all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vector.dll vals.dll
	mcs -target:exe -reference:matrix.dll -reference:vector.dll -reference:vals.dll main.cs

vals.dll: vals.cs vector.dll matrix.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll  vals.cs

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library vector.cs 

clean:
	$(RM) *.exe *.txt *.dll
