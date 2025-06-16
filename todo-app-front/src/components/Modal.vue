<script setup>
import VueDatePicker from '@vuepic/vue-datepicker';
</script>

<template>
    <main v-if="isAdding || isEditing">
      <div class="modal-backdrop">
      <div class="modal">
          <h2 v-if="isAdding">Nowe Zadanie</h2>
          <h2 v-else="isAdding">Edytuj Zadanie</h2>
          <p>Tytuł:</p>
          <input v-model="editableTitle" placeholder="Tytuł" />
          <p>Opis:</p>
          <textarea v-model="editableDescription" placeholder="Opis"></textarea>
          <p>Data wykonania: <VueDatePicker v-model="editableDate" :enable-time-picker="true"/></p>
          <div>
            <button class="modal-btn" v-if="isAdding" @click="addTodo">Dodaj zadanie</button>
            <button class="modal-btn" v-else @click="editTodo">Edytuj zadanie</button>

            <button class="modal-btn" @click="$emit('cancelOperation')">Zamknij</button>
          </div>
      </div>
      </div> 
    </main>
</template>

<script>
  export default {
    props: ['isAdding', 'isEditing', 'data'],
    data() {
      return {
        editableTitle: '',
        editableDescription: '',
        editableDate: '',
      }
    },
    components: {
      VueDatePicker
    },
    methods: {
      addTodo() {
        let todo = {
          title: this.editableTitle,
          description: this.editableDescription,
          date: this.editableDate,
        }

        this.$emit('addTodo', todo)
      },
      editTodo() {
        let todo = {
          id: this.data.id,
          title: this.editableTitle,
          description: this.editableDescription,
          date: this.editableDate,
        }
        
        this.$emit('editTodo', todo)
      },
    },
    watch: {
      data: {
        handler(newData) {
          this.editableTitle = newData?.title ?? ''
          this.editableDescription = newData?.description ?? ''
          this.editableDate = newData?.date ?? new Date()
        },
        immediate: true
      }
    }
    }

</script>
<style lang="css">

.modal-backdrop {
  position: fixed;
  inset: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}


.modal {
  background-color: white;
  padding: 2rem;
  border-radius: 12px;
  width: 100%;
  max-width: 500px;
  box-shadow: 0 20px 50px rgba(0, 0, 0, 0.2);
  z-index: 1001;
  position: relative;
}


.modal-btn {
  margin-top: 1rem;
  margin-right: 1rem;
  padding: 0.5rem 1rem;
  background-color: #3b82f6;
  color: white;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}

</style>