All : harm.svg damp_harm.svg pend.svg

pend.svg: pend.gpi Out.txt
	gnuplot $<

damp_harm.svg: damp_harm.gpi Out.txt
	gnuplot $<

harm.svg: harm.gpi Out.txt
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll
	mcs main.cs -reference:matrix.dll -target:exe -out:main.exe

matrix.dll: vector.cs matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm --force Out.txt main.exe *.dll *.data *.svg
