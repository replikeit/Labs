# Makefile for Task2

bin/Task2: build/Task2.out build/note.out
	gcc -o bin/Task2 build/Task2.out build/note.out

build/Task2.out: src/Task2.c
	gcc -c src/Task2.c -o build/Task2.out

build/note.out: src/note.c
	gcc -c src/note.c -o build/note.out

clean: 
	rm -f build/*.out bin/Task2

run: 
	bin/Task2
