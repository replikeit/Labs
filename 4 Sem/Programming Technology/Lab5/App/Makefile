# Makefile for Task3

bin/AirDelivery: build/main.out build/sqlite3.out build/functions.out build/inquiries.out
	gcc -o bin/AirDelivery build/main.out -ldl build/sqlite3.out build/functions.out build/inquiries.out

build/main.out: src/main.c
	gcc -c src/main.c -o build/main.out

build/sqlite3.out: src/sqlite3.c
	gcc -c src/sqlite3.c -o build/sqlite3.out

build/functions.out: src/functions.c
	gcc -c src/functions.c -o build/functions.out

build/inquiries.out: src/inquiries.c
	gcc -c src/inquiries.c -o build/inquiries.out

clean: 
	rm -f build/*.out bin/Task3

