<script setup>

import axios from 'axios'
import Todos from './components/Todos.vue';
import VueDatePicker from '@vuepic/vue-datepicker';
import Modal from './components/Modal.vue'

</script>

<template>
  <nav>
    <section id="title">Todo list by Mateusz Ostrowski</section>
  </nav>

  <main>
    <Modal :isAdding="isAddingTodo"
     :isEditing="isEditingTodo"
      :data="editData"
       @cancelOperation="onCancelOperation"
       @addTodo="saveTodo"
       @editTodo="editTodo"/>

    <header id="todo-header">
      <h1>Zadania</h1>
      <section id="todo-header-datepicker">  
        <section> Wybierz dzień: </section>
        <VueDatePicker v-model="date" @update:modelValue="fetchTodos" auto-apply :enable-time-picker="false"/>
        <button @click="triggerAddTodo">Dodaj zadanie</button>
      </section>
    </header>
    <section class="tasks">
      <section class="todos">
        <h2 class="header-text">Aktualne zadania</h2>
        <Todos ref="todos"
          :todos="activeTodos"
          :editable="true"
          :message="'Skąd to zwątpienie?'"
          @deleteTodoFromDb="deleteTodo"
          @emitTriggerEditTodo="triggerEditTodo"
          @doneTodoInDb="doneTodo"/>
      </section>
      <section class="todos">
        <h2 class="header-text">Zadania wykonane</h2>
        <Todos
          :todos="doneTodos"
          :message="'Dasz radę! Wykonaj jeszcze parę tasków'"
          :editable="false"
          @doneTodoInDb="doneTodo"/>
      </section>
      <section class="todos">
        <h2 class="header-text">Spóźnione zadania</h2>
        <Todos
         :todos="outdatedTodos"
         :message="'Całe szczęście nic tutaj nie ma'"
         :editable="true"
          @deleteTodoFromDb="deleteTodo"
          @emitTriggerEditTodo="triggerEditTodo"
          @doneTodoInDb="doneTodo"/>
      </section>
    </section>
  </main>
</template>

<script>
  export default {
    data() {
      return {
        todos: [],
        activeTodos: [],
        doneTodos: [],
        outdatedTodos: [],
        isAddingTodo: false,
        isEditingTodo: false,
        editData: {},
        date: new Date(),
      }
    },
    components: {
      Todos,
      Modal
    },
    methods: {
      async fetchTodos() {
        try {
          const response = await axios.get(`${import.meta.env.VITE_API_URL}/todos`, {
              params: { date: this.date }
          })
          this.todos = response.data

          this.updateTodoArrays()
        }
        catch (error) {
          console.error('Błąd podczas pobierania danych:', error)
        }
      },
      deleteTodo(id) {
        axios.delete(`${import.meta.env.VITE_API_URL}/todos`, {
          params: { id: id }
        })

        this.todos = this.todos.filter(item => item.id != id)
        this.updateTodoArrays()
      },
      async editTodo(dto) {
        this.isEditingTodo = false
        try {
          await axios.put(`${import.meta.env.VITE_API_URL}/todos`, dto)

          this.todos = this.todos.map(todo =>
            todo.id === dto.id ? {
              ...todo,
              title: dto.title,
              description: dto.description,
              date: dto.date,
            } : todo
          )

          this.fetchTodos()
        } catch(error) {
          console.error('Błąd podczas pobierania danych:', error)
        }
      },
      async doneTodo(id) {
        try {
          await axios.put(`${import.meta.env.VITE_API_URL}/todos/${id}`)

          this.todos = this.todos.map(todo =>
            todo.id === id ? {
              ...todo,
              isDone: !todo.isDone
            } : todo
          )
          this.updateTodoArrays()

        } catch(error) {
          console.error('Błąd podczas pobierania danych:', error)
        }  
      },
      async saveTodo(todo) {
        this.isAddingTodo = false

        try {
          var todo = await axios.post(`${import.meta.env.VITE_API_URL}/todos`, todo)

          this.todos.push(todo.data)

          this.updateTodoArrays()
        } catch(error) {
          console.error('Błąd podczas zapisywania danych:', error)
        }
      },
      checkUpcomingTasks() {
          let upcomingTodos = this.todos.filter(todo => {
            let milliseconds = new Date(todo.date) - new Date()
            let diffMinutes = milliseconds / 60000

            return diffMinutes <= 15 && diffMinutes >= 0 && !todo.isDone
          })

          if(upcomingTodos.length > 0)
            alert("Masz " + upcomingTodos.length + " zadań do wykonania")

          this.updateTodoArrays()
      },
      updateTodoArrays() {
          this.activeTodos = this.todos.filter(todo => !todo.isDone && new Date() < new Date(todo.date))
          this.doneTodos = this.todos.filter(todo => todo.isDone)
          this.outdatedTodos = this.todos.filter(todo => !todo.isDone && new Date() > new Date(todo.date))
      },
      triggerAddTodo() {
        this.editData = {
          date: this.date
        }

        this.isAddingTodo = true
      },
      triggerEditTodo(id, todoData) {
        let fullTodoData = {
          id: id,
          ...todoData
        }

        this.editData = fullTodoData
        this.isEditingTodo = true
      },
      onCancelOperation() {
        this.isAddingTodo = false
        this.isEditingTodo = false
      },
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

.header-text {
  text-align: center;
}

.tasks {
  display: flex;
  flex-direction: row;
}

.todos {
  width: 33%;
}
</style>
