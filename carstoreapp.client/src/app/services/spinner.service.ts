import { Injectable, signal, computed } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SpinnerService {
  // Private counter signal
  private loadingCount = signal(0);
  private message = signal('');

  // Public computed signals
  isLoading = computed(() => this.loadingCount() > 0);
  currentMessage = computed(() => this.message());

  show(message: string = '') {
    this.loadingCount.update((count) => count + 1);
    this.message.set(message);
  }

  hide() {
    this.loadingCount.update((count) => Math.max(0, count - 1));
    if (this.loadingCount() === 0) {
      this.message.set('');
    }
  }

  // Optional: Force reset all loaders
  reset() {
    this.loadingCount.set(0);
    this.message.set('');
  }
}
