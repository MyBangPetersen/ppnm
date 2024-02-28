out_main.txt:  input.txt Makefile
	cat input.txt | mono main.exe 1> $@

tablereader.exe: main.cs glist.dll
	mcs -out:$@ -target:exe -reference:glist.dll main.cs

glist.dll: glist.cs
	mcs -out:$@ -target:library glist.cs

.PHONEY: clean
clean:
	$(RM) glist.dll *.exe log* [Oo]ut*
