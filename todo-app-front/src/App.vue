<script setup>

import { ref, onMounted } from 'vue'
import axios from 'axios'
import Todos from './components/Todos.vue';
import VueDatePicker from '@vuepic/vue-datepicker';
import Notifications from './components/Notifications.vue';

</script>

<template>
  <nav>
    <section id="title">Todo list by Mateusz Ostrowski</section>
    <section>
      <Notifications :todos="todos"/>
    </section>
  </nav>

  <main>
    <header id="todo-header">
      <h1>Zadania</h1>
      <section id="todo-header-datepicker">  
        <section> Wybierz dzień: </section>
        <VueDatePicker v-model="date" @update:modelValue="fetchTodos" auto-apply/>
        <button @click="triggerAddTodo">Dodaj zadanie</button>
      </section>
    </header>
    <Todos ref="todos" :todos="todos" @deleteTodoFromDb="deleteTodo" @editTodoInDb="editTodo" @saveTodoInDb="saveTodo" />
  </main>
</template>

<script>
  export default {
    data() {
      return {
        todos: [],
        date: new Date()
      }
    },
    components: {
      Todos
    },
    methods: {
      async fetchTodos() {
        try {
          const response = await axios.get('/api/todos', {
              params: { date: this.prepareCorrectDate() }
          })

          this.todos = response.data
        }
        catch (error) {
          console.error('Błąd podczas pobierania danych:', error)
        }
      },
      prepareCorrectDate() {
          var month = this.date.getMonth() + 1 < 10 ? "0" + (this.date.getMonth() + 1) : this.date.getMonth() + 1
          var newDate =  this.date.getFullYear() + '-' + month + '-' + this.date.getDate()
          return newDate
      },
      deleteTodo(id) {
        axios.delete('api/todos', {
          params: { id: id }
        })

        this.todos = this.todos.filter(item => item.id != id)
      },
      async editTodo(id, todoData) {
        const dto = {
          id: id,
          title: todoData.title,
          description: todoData.description,
          date: this.prepareCorrectDate()
        }

        try {
          await axios.put('/api/todos', {
            id: id,
            title: todoData.title,
            description: todoData.description,
            date: this.prepareCorrectDate()
          })

          this.todos.map(todo =>
            todo.id === id ? {
              ...todo,
              title: todoData.title,
              description: todoData.description
            } : todo
          )

          this.fetchTodos()
        } catch(error) {
          console.error('Błąd podczas pobierania danych:', error)
        }
      },
      async saveTodo(title, description) {
        try {
          await axios.post('/api/todos', {
            title: title,
            description: description,
            date: this.prepareCorrectDate()
          })

          this.fetchTodos()
        } catch(error) {
          console.error('Błąd podczas zapisywania danych:', error)
        }
      },
      checkUpcomingTasks() {

      },
      triggerAddTodo() {
        this.$refs.todos.triggerAddTodo()
      }
    },
    mounted() {
      this.fetchTodos()
      this.interval = setInterval(this.checkUpcomingTasks, 60000)
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

section#title {
  color: white;
  width: 25%;
  padding: 10px;
  letter-spacing: 1.5px;
}

section > img {
  height: 24px;
  width: 24px;
}

main {
  display: flex;
  flex-direction: column;
  width: 70%;
  margin-left: auto;
  margin-right: auto;
  align-items: center;
  color: black;
  justify-content: flex-start;
}

#todo-header {
  display: flex;
  flex-direction: column;
}

#todo-header-datepicker {
  display: flex;
  align-items: center;
  flex-direction: row;
  -ms-flex-align: end;
}

</style>
