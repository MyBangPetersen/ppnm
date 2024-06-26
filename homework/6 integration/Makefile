out.erf.png: out.txt Makefile
		echo '\
					set terminal png background "white";\
					set out "$@";\
					set ylabel "erf(x)";\
					set xlabel "x";\
					set title "integral representation of the errorfunction";\
					set grid;\
					plot\
							"$<" index 1 with lines title "erf(x)"\
							,"$<" index 2 with points pointtype 2 title "table values"; \
					'| tee erf.log.gpi | gnuplot

out.txt:main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs integ.dll
	mcs -target:exe -out:main.exe -reference:integ.dll main.cs

integ.dll:integ.cs
	mcs -target:library -out:integ.dll integ.cs

clean:
	$(RM) *.exe *.dll *.gpi *.png [Oo]ut*
