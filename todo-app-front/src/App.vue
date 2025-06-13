<script setup>

import { ref, onMounted } from 'vue'
import axios from 'axios'
import Todo from './components/Todo.vue';

</script>

<template>
  <nav>
    <section id="title">Todo list by Mateusz Ostrowski</section>
    <section id="image">
      <input type="text" value="Wpisz date"/>
      <button v-on:click="fetchTodos">Klik</button>
      <img src="./components/icons/bell.png" alt="notification-icon">
    </section>
  </nav>

  <main id="main">
    <section v-if="todos.length == 0">Ups! niczego tutaj nie ma :/ Dodaj nowe zadanie</section>
    <section v-else>
      <Todo v-for="todo in todos"
         :title="todo.title"
         :description="todo.description"
         :date="todo.date"
         v-on:emitDeleteTodo="deleteTodo(todo.id)"
         v-on:emitEditTodo="editTodo"></Todo>
    </section>
  </main>
</template>

<script>
  export default {
    data() {
      return {
        todos: []
      }
    },
    components: {
      Todo
    },
    methods: {
      async fetchTodos() {
        try {
          const response = await axios.get('/api/todos', {
              params: { date: '2025-06-13' }
          })
          this.todos = response.data
        }
        catch (error) {
          console.error('Błąd podczas pobierania danych:', error)
        }
      },
      deleteTodo(id) {
        axios.delete('api/todos', {
          params: { id: id }
        })

        this.todos = this.todos.filter(item => item.id != id)
      },
      editTodo() {
        
      }
    } 
  }
</script>

<style scoped>
nav {
  display: inline-flex;
  margin: 0;
  background-color: #2AACE6;
  width: 100%;
  padding: 10;
  color: black;
}

section {
  padding: 10px;
  letter-spacing: 1.5px;
}

section#title {
  color: white;
  width: 25%;
}

section#image {
  display: flex;
  justify-content: flex-end;
  width: 75%;
}

section > img {
  height: 24px;
  width: 24px;
}

main {
  display: flex;
  justify-content: center;
  color: black;
}

</style>
