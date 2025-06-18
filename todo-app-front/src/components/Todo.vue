<template>
  <div class="todo-item">
    <div>
        <input type="checkbox" :checked="localIsDone" @click="emitDoneTodo">
    </div>
    <div class="todo-content">
      <div>
        <h3>{{ title }}</h3>
        <p>{{ description }}</p>
        <span>{{ date }}</span>
      </div>
    </div>
    <div class="todo-actions" v-if="editable">
      <button class="edit-btn" @click="editTodo"><img src="./icons/edit.png" alt="Edit button icon"></button>
      <button class="delete-btn" @click="$emit('emitDeleteTodo')">X</button>
    </div>
  </div>
</template>

<script>

  export default {
    props: ['editable', 'title', 'description', 'date', 'isDone'],
    data() {
      return {
        localTitle: this.title ?? '',
        localDescription: this.description ?? '',
        localDate: this.date ?? '',
        localIsDone: this.isDone
      }
    },
    methods: {
      editTodo() {
          let todo = {
            title: this.localTitle,
            description: this.localDescription,
            date: this.localDate,
          }
          
          this.$emit('emitEditTodo', todo)
      },
      emitDoneTodo() {
        this.localIsDone = !this.localIsDone
        this.$emit('emitDoneTodo')
      }
    }
  }
</script>

<style scoped>

.todo-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #f9fafb;
  border: 1px solid #e5e7eb;
  border-radius: 12px;
  padding: 16px;
  margin-bottom: 12px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.04);
  transition: background 0.3s;
}

.todo-item:hover {
  background: #f1f5f9;
}

.todo-content {
  flex: 1;
}

.todo-title {
  margin: 0;
  font-size: 1.1rem;
  font-weight: 600;
  color: #111827;
}

.todo-description {
  margin: 4px 0;
  color: #4b5563;
  font-size: 0.95rem;
}

.todo-date {
  font-size: 0.85rem;
  color: #6b7280;
}

.todo-actions {
  display: flex;
  gap: 10px;
}

.edit-btn,
.delete-btn {
  color: red;
  border: none;
  background: transparent;
  font-size: 1.2rem;
  cursor: pointer;
  transition: transform 0.2s ease;
}

.edit-btn:hover {
  color: #2563eb;
  transform: scale(1.1);
}

span {
  margin-right: 1rem;
}

.delete-btn:hover {
  color: #dc2626;
  transform: scale(1.1);
}

</style>
