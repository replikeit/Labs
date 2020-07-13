# Makefile for Task3

bin/Task3: build/Task3.out build/worker.out build/sqlite3.out
	gcc -o bin/Task3 build/Task3.out build/sqlite3.out build/worker.out 

build/Task3.out: src/Task3.c
	gcc -c src/Task3.c -o build/Task3.out

build/sqlite3.out: src/sqlite3.c
	gcc -c src/sqlite3.c -o build/sqlite3.out

build/worker.out: src/worker.c
	gcc -c src/worker.c -o build/worker.out

clean: 
	rm -f build/*.out bin/Task3

