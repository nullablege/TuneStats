(() => {
  const sidebar = document.getElementById("sidebar");
  const menuToggle = document.getElementById("menuToggle");
  const sidebarOverlay = document.getElementById("sidebarOverlay");

  if (!sidebar || !menuToggle || !sidebarOverlay) {
    return;
  }

  const closeSidebar = () => {
    sidebar.classList.remove("open");
    sidebarOverlay.classList.remove("active");
  };

  menuToggle.addEventListener("click", () => {
    sidebar.classList.toggle("open");
    sidebarOverlay.classList.toggle("active", sidebar.classList.contains("open"));
  });

  sidebarOverlay.addEventListener("click", closeSidebar);

  document.addEventListener("keydown", (event) => {
    if (event.key === "Escape") {
      closeSidebar();
    }
  });
})();

(() => {
  const updateModal = document.getElementById("updateModal");

  if (!updateModal) {
    return;
  }

  const closeModal = () => updateModal.classList.remove("active");
  const fields = {
    DinlemeId: document.getElementById("updateDinlemeId"),
    AdSoyad: document.getElementById("updateAdSoyad"),
    Yas: document.getElementById("updateYas"),
    Il: document.getElementById("updateIl"),
    Ilce: document.getElementById("updateIlce"),
    Sanatci: document.getElementById("updateSanatci"),
    Sarki: document.getElementById("updateSarki"),
    Tur: document.getElementById("updateTur")
  };

  document.querySelectorAll(".open-update-modal").forEach((button) => {
    button.addEventListener("click", () => {
      fields.DinlemeId.value = button.dataset.id;
      fields.AdSoyad.value = button.dataset.adsoyad;
      fields.Yas.value = button.dataset.yas;
      fields.Il.value = button.dataset.il;
      fields.Ilce.value = button.dataset.ilce;
      fields.Sanatci.value = button.dataset.sanatci;
      fields.Sarki.value = button.dataset.sarki;
      fields.Tur.value = button.dataset.tur;
      updateModal.classList.add("active");
    });
  });

  document.getElementById("closeUpdateModal").addEventListener("click", closeModal);
  document.getElementById("cancelUpdateModal").addEventListener("click", closeModal);

  updateModal.addEventListener("click", (event) => {
    if (event.target === updateModal) {
      closeModal();
    }
  });
})();
