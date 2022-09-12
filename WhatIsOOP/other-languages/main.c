#include <stdio.h>
#include <stdlib.h>

// List:
//  - new
//  - get
//  - push
//  - removeLast

struct List {
    struct Node* first;
    struct Node* last;
};

struct Node {
    int elem;
    struct Node* next;
};

struct Node* newNode(int elm) {
    struct Node* n = malloc(sizeof(struct Node));
    n->elem = elm;
    n->next = NULL;
    return n;
}

int main() {
    printf("Hello world!\n");
    return 0;
}

// TIL:
//  - stdin, stdout - это потоки вв/вывода UNIX