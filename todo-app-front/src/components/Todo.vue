<template>
  <div class="todo-item">
    <div class="todo-content">
      <template v-if="isEditing">
        <input v-model="editableTitle" class="edit-input" />
        <textarea v-model="editableDescription" class="edit-textarea"></textarea>
        <button class="save-btn" @click="saveChanges">Zapisz</button>
        <button class="cancel-btn" @click="cancelEdit">Anuluj</button>
      </template>
      <template v-else>
        <h3 class="todo-title">{{ title }}</h3>
        <p class="todo-description">{{ description }}</p>
        <span class="todo-date">{{ date }}</span>
      </template>
    </div>
    <div class="todo-actions" v-if="!isEditing">
      <button class="edit-btn" @click="startEditing"><img src="./icons/edit.png" alt="Edit button icon"></button>
      <button class="delete-btn" @click="$emit('emitDeleteTodo')">X</button>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['title', 'description', 'date'],
    data() {
      return {
        isEditing: false,
        isAdding: false,
        editableTitle: this.title,
        editableDescription: this.description
      }
    },
      methods: {
        startEditing() {
          this.isEditing = true
        },
        cancelEdit() {
          this.isEditing = false
        },
        saveChanges() {
          this.isEditing = false
          this.$emit('emitUpdateTodo', {
            title: this.editableTitle,
            description: this.editableDescription
          })
        }
    }
  }
</script>

<style scoped>

main {
  padding: 20px;
}

.todo-item {
  min-width: 400px;
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

.delete-btn:hover {
  color: #dc2626;
  transform: scale(1.1);
}

</style>
