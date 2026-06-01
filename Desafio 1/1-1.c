#include<stdio.h>
#include <stdlib.h>


struct no {
    int info;         
    struct no * prox;
};

struct no * novoNo(int info) {
    struct no * novo = malloc(sizeof(struct no));
    novo->info = info;
    return novo;
}

struct no * insert_first(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    if (!novo) return lista;   
    novo->prox = lista;        
    return novo;               
}

void insert_last(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    
    struct no *curr = lista;
    while (curr->prox != NULL) {
        curr = curr->prox;
    }
    curr->prox = novo;
}

struct no * remove_first(struct no * lista) {
    if (lista == NULL) return NULL; 

    struct no *novo_inicio = lista->prox;
    return novo_inicio;
}

void print_list(struct no *lista) {
    struct no *curr = lista;

    while (curr != NULL) {
        printf("%d ", curr->info);
        curr = curr->prox;
    }

    printf("\n");
}

int main() {
    
    struct no *lista = NULL;

    lista = insert_first(lista, 10);
    lista = insert_first(lista, 5);
    lista = insert_first(lista, 1);
    
    print_list(lista);
    
    return 0;
}