
out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs minimize.dll
	mcs -target:exe -out:main.exe -reference:minimize.dll main.cs

minimize.dll: min.cs matrix.cs vector.cs QRGS.cs
	mcs -target:library -out:minimize.dll minimize.cs matrix.cs vector.cs QRGS.cs

clean:
	$(RM) *.exe *.dll *.txt
